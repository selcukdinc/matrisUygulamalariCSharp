import datetime

def generate_svg(commits_file):
    svg_lines = []
    y_pos = 50
    svg_lines.append('<svg width="600" height="400">')
    svg_lines.append('<rect width="100%" height="100%" fill="lightblue" />')
    svg_lines.append('<text x="20" y="30" font-size="20">Commit History</text>')

    with open(commits_file, 'r') as f:
        for commit_data in f:
            date, hash, message = commit_data.strip().split('|')
            date_obj = datetime.datetime.strptime(date, '%d.%m.%Y')
            date_str = date_obj.strftime('%d %b %Y')

            svg_lines.append(f'<circle cx="50" cy="{y_pos}" r="10" fill="darkgreen" />')
            svg_lines.append(f'<text x="80" y="{y_pos + 5}" font-size="12">{date_str} - {hash} - {message}</text>')
            y_pos += 30

    svg_lines.append('</svg>')
    return '\n'.join(svg_lines)


if __name__ == "__main__":
    svg_content = generate_svg("commits.txt")
    with open("commits.svg", "w") as f:
        f.write(svg_content)
